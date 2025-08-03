import { BasePage } from '@/components/layouts/BasePage';
import React, { useEffect, useState, useMemo } from 'react';
import { Stack, Box, Title, Text, Button, Group, Modal, TextInput } from '@mantine/core';
import { useCurFieldsofstudy } from '@/data/curfieldsofstudy/curfieldsofstudy.query';
import { DkdGrid } from '@dkd-grid';
import type { ColumnDef } from '@tanstack/react-table';
import type { CurFieldsofstudyDto } from '@/data/curfieldsofstudy/curfieldsofstudy.models';
import { useDisclosure } from '@mantine/hooks';
import { notifications } from '@mantine/notifications';

export default function IndexPage() {
    const { useGetAll, useCreate, useUpdate, useDelete } = useCurFieldsofstudy();
    const { data: curFieldsofstudyData, isLoading, refetch } = useGetAll();
    const createMutation = useCreate();
    const updateMutation = useUpdate();
    const deleteMutation = useDelete();
    
    const [selectedRowId, setSelectedRowId] = useState<string | null>(null);
    const [editingFieldOfStudy, setEditingFieldOfStudy] = useState<CurFieldsofstudyDto | null>(null);
    const [opened, { open, close }] = useDisclosure(false);

    const data = curFieldsofstudyData?.result || [];

    // تعریف ستون‌های جدول
    const columns = useMemo<ColumnDef<CurFieldsofstudyDto>[]>(() => [
        {
            accessorKey: 'id',
            header: 'شناسه',
            size: 80,
        },
        {
            accessorKey: 'name',
            header: 'نام رشته تحصیلی',
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
    const handleEdit = (row: CurFieldsofstudyDto) => {
        setEditingFieldOfStudy(row);
        open();
    };

    const handleDelete = async (row: CurFieldsofstudyDto) => {
        try {
            await deleteMutation.mutateAsync(row.id);
            notifications.show({
                title: 'موفقیت',
                message: 'رشته تحصیلی با موفقیت حذف شد',
                color: 'green',
            });
            refetch();
        } catch (error) {
            notifications.show({
                title: 'خطا',
                message: 'خطا در حذف رشته تحصیلی',
                color: 'red',
            });
        }
    };

    const handleAdd = () => {
        setEditingFieldOfStudy(null);
        open();
    };

    const handleSave = async (values: Partial<CurFieldsofstudyDto>) => {
        try {
            if (editingFieldOfStudy) {
                await updateMutation.mutateAsync({ id: editingFieldOfStudy.id, ...values });
                notifications.show({
                    title: 'موفقیت',
                    message: 'رشته تحصیلی با موفقیت ویرایش شد',
                    color: 'green',
                });
            } else {
                await createMutation.mutateAsync(values);
                notifications.show({
                    title: 'موفقیت',
                    message: 'رشته تحصیلی جدید با موفقیت ایجاد شد',
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
                    <Title order={2}>مدیریت رشته‌های تحصیلی</Title>
                    <Text c="dimmed">مدیریت رشته‌های مختلف تحصیلی</Text>
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
                    title={editingFieldOfStudy ? 'ویرایش رشته تحصیلی' : 'افزودن رشته تحصیلی جدید'}
                    size="md"
                >
                    <Stack gap="md">
                        <TextInput
                            label="نام رشته تحصیلی"
                            placeholder="نام رشته تحصیلی"
                            defaultValue={editingFieldOfStudy?.name || ''}
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
                                {editingFieldOfStudy ? 'ویرایش' : 'افزودن'}
                            </Button>
                        </Group>
                    </Stack>
                </Modal>
            </Stack>
        </BasePage>
    );
} 