import { BasePage } from '@/components/layouts/BasePage';
import React, { useEffect, useState, useMemo } from 'react';
import { Stack, Box, Title, Text, Button, Group, Modal, TextInput } from '@mantine/core';
import { useCurSpecializations } from '@/data/curspecializations/curspecializations.query';
import { DkdGrid } from '@dkd-grid';
import type { ColumnDef } from '@tanstack/react-table';
import type { CurSpecializationsDto } from '@/data/curspecializations/curspecializations.models';
import { useDisclosure } from '@mantine/hooks';
import { notifications } from '@mantine/notifications';

export default function IndexPage() {
    const { useGetAll, useCreate, useUpdate, useDelete } = useCurSpecializations();
    const { data: curSpecializationsData, isLoading, refetch } = useGetAll();
    const createMutation = useCreate();
    const updateMutation = useUpdate();
    const deleteMutation = useDelete();
    
    const [selectedRowId, setSelectedRowId] = useState<string | null>(null);
    const [editingSpecialization, setEditingSpecialization] = useState<CurSpecializationsDto | null>(null);
    const [opened, { open, close }] = useDisclosure(false);

    const data = curSpecializationsData?.result || [];

    // تعریف ستون‌های جدول
    const columns = useMemo<ColumnDef<CurSpecializationsDto>[]>(() => [
        {
            accessorKey: 'id',
            header: 'شناسه',
            size: 80,
        },
        {
            accessorKey: 'name',
            header: 'نام تخصص',
            size: 200,
        },
        {
            accessorKey: 'createTime',
            header: 'تاریخ ایجاد',
            size: 150,
            cell: ({ getValue }: { getValue: () => any }) => {
                const date = getValue() as string;
                return date ? new Date(date).toLocaleDateString('fa-IR') : '-';
            },
        },
    ], []);

    // هندل‌های CRUD
    const handleEdit = (row: CurSpecializationsDto) => {
        setEditingSpecialization(row);
        open();
    };

    const handleDelete = async (row: CurSpecializationsDto) => {
        try {
            await deleteMutation.mutateAsync(row.id);
            notifications.show({
                title: 'موفقیت',
                message: 'تخصص با موفقیت حذف شد',
                color: 'green',
            });
            refetch();
        } catch (error) {
            notifications.show({
                title: 'خطا',
                message: 'خطا در حذف تخصص',
                color: 'red',
            });
        }
    };

    const handleAdd = () => {
        setEditingSpecialization(null);
        open();
    };

    const handleSave = async (values: Partial<CurSpecializationsDto>) => {
        try {
            if (editingSpecialization) {
                await updateMutation.mutateAsync({ id: editingSpecialization.id, ...values });
                notifications.show({
                    title: 'موفقیت',
                    message: 'تخصص با موفقیت ویرایش شد',
                    color: 'green',
                });
            } else {
                await createMutation.mutateAsync(values);
                notifications.show({
                    title: 'موفقیت',
                    message: 'تخصص جدید با موفقیت ایجاد شد',
                    color: 'green',
                });
            }
            close();
            refetch();
        } catch (error) {
            notifications.show({
                title: 'خطا',
                message: 'خطا در ذخیره‌سازی',
                color: 'red',
            });
        }
    };

    return (
        <BasePage>
            <Stack gap="lg">
                <Box>
                    <Title order={2}>مدیریت تخصص‌ها</Title>
                    <Text c="dimmed">مدیریت تخصص‌های مختلف</Text>
                </Box>

                <DkdGrid
                    columns={columns}
                    data={data}
                    isLoading={isLoading}
                    rtl
                    height={600}
                    selectedRowId={selectedRowId}
                    onRowClick={(row: any) => setSelectedRowId(row.original.id.toString())}
                    onEdit={handleEdit}
                    onDelete={handleDelete}
                    onAdd={handleAdd}
                    initialPageSize={15}
                />

                {/* Modal برای افزودن/ویرایش */}
                <Modal 
                    opened={opened} 
                    onClose={close} 
                    title={editingSpecialization ? 'ویرایش تخصص' : 'افزودن تخصص جدید'}
                    size="md"
                >
                    <Stack gap="md">
                        <TextInput
                            label="نام تخصص"
                            placeholder="نام تخصص"
                            defaultValue={editingSpecialization?.name || ''}
                            name="name"
                            required
                        />
                        
                        <Group justify="flex-end" mt="md">
                            <Button variant="outline" onClick={close}>
                                انصراف
                            </Button>
                            <Button 
                                onClick={() => {
                                    const formData = new FormData(document.querySelector('form') as HTMLFormElement);
                                    const values = {
                                        name: (formData.get('name') as string) || '',
                                    };
                                    handleSave(values);
                                }}
                                loading={createMutation.isPending || updateMutation.isPending}
                            >
                                {editingSpecialization ? 'ویرایش' : 'افزودن'}
                            </Button>
                        </Group>
                    </Stack>
                </Modal>
            </Stack>
        </BasePage>
    );
} 