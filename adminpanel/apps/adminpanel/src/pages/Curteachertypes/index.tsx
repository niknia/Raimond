import { BasePage } from '@/components/layouts/BasePage';
import React, { useEffect, useState, useMemo } from 'react';
import { Stack, Box, Title, Text, Button, Group, Modal, TextInput } from '@mantine/core';
import { useCurTeacherTypes } from '@/data/curteachertypes/curteachertypes.query';
import { DkdGrid } from '@dkd-grid';
import type { ColumnDef } from '@tanstack/react-table';
import type { CurTeacherTypesDto } from '@/data/curteachertypes/curteachertypes.models';
import { useDisclosure } from '@mantine/hooks';
import { notifications } from '@mantine/notifications';

export default function IndexPage() {
    const { useGetAll, useCreate, useUpdate, useDelete } = useCurTeacherTypes();
    const { data: curTeacherTypesData, isLoading, refetch } = useGetAll();
    const createMutation = useCreate();
    const updateMutation = useUpdate();
    const deleteMutation = useDelete();
    
    const [selectedRowId, setSelectedRowId] = useState<string | null>(null);
    const [editingTeacherType, setEditingTeacherType] = useState<CurTeacherTypesDto | null>(null);
    const [opened, { open, close }] = useDisclosure(false);

    const data = curTeacherTypesData?.result || [];

    // تعریف ستون‌های جدول
    const columns = useMemo<ColumnDef<CurTeacherTypesDto>[]>(() => [
        {
            accessorKey: 'id',
            header: 'شناسه',
            size: 80,
        },
        {
            accessorKey: 'name',
            header: 'نام نوع معلم',
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
    const handleEdit = (row: CurTeacherTypesDto) => {
        setEditingTeacherType(row);
        open();
    };

    const handleDelete = async (row: CurTeacherTypesDto) => {
        try {
            await deleteMutation.mutateAsync(row.id);
            notifications.show({
                title: 'موفقیت',
                message: 'نوع معلم با موفقیت حذف شد',
                color: 'green',
            });
            refetch();
        } catch (error) {
            notifications.show({
                title: 'خطا',
                message: 'خطا در حذف نوع معلم',
                color: 'red',
            });
        }
    };

    const handleAdd = () => {
        setEditingTeacherType(null);
        open();
    };

    const handleSave = async (values: Partial<CurTeacherTypesDto>) => {
        try {
            if (editingTeacherType) {
                await updateMutation.mutateAsync({ id: editingTeacherType.id, ...values });
                notifications.show({
                    title: 'موفقیت',
                    message: 'نوع معلم با موفقیت ویرایش شد',
                    color: 'green',
                });
            } else {
                await createMutation.mutateAsync(values);
                notifications.show({
                    title: 'موفقیت',
                    message: 'نوع معلم جدید با موفقیت ایجاد شد',
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
                    <Title order={2}>مدیریت انواع معلمان</Title>
                    <Text c="dimmed">مدیریت انواع مختلف معلمان و اساتید</Text>
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
                    title={editingTeacherType ? 'ویرایش نوع معلم' : 'افزودن نوع معلم جدید'}
                    size="md"
                >
                    <Stack gap="md">
                        <TextInput
                            label="نام نوع معلم"
                            placeholder="نام نوع معلم"
                            defaultValue={editingTeacherType?.name || ''}
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
                                {editingTeacherType ? 'ویرایش' : 'افزودن'}
                            </Button>
                        </Group>
                    </Stack>
                </Modal>
            </Stack>
        </BasePage>
    );
}
