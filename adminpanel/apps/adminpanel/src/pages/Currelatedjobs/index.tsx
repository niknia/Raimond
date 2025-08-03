import { BasePage } from '@/components/layouts/BasePage';
import React, { useEffect, useState, useMemo } from 'react';
import { Stack, Box, Title, Text, Button, Group, Modal, TextInput } from '@mantine/core';
import { useCurRelatedjobs } from '@/data/currelatedjobs/currelatedjobs.query';
import { DkdGrid } from '@dkd-grid';
import type { ColumnDef } from '@tanstack/react-table';
import type { CurRelatedjobsDto } from '@/data/currelatedjobs/currelatedjobs.models';
import { useDisclosure } from '@mantine/hooks';
import { notifications } from '@mantine/notifications';

export default function IndexPage() {
    const { useGetAll, useCreate, useUpdate, useDelete } = useCurRelatedjobs();
    const { data: curRelatedjobsData, isLoading, refetch } = useGetAll();
    const createMutation = useCreate();
    const updateMutation = useUpdate();
    const deleteMutation = useDelete();
    
    const [selectedRowId, setSelectedRowId] = useState<string | null>(null);
    const [editingRelatedJob, setEditingRelatedJob] = useState<CurRelatedjobsDto | null>(null);
    const [opened, { open, close }] = useDisclosure(false);

    const data = curRelatedjobsData?.result || [];

    // تعریف ستون‌های جدول
    const columns = useMemo<ColumnDef<CurRelatedjobsDto>[]>(() => [
        {
            accessorKey: 'id',
            header: 'شناسه',
            size: 80,
        },
        {
            accessorKey: 'name',
            header: 'نام شغل مرتبط',
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
    const handleEdit = (row: CurRelatedjobsDto) => {
        setEditingRelatedJob(row);
        open();
    };

    const handleDelete = async (row: CurRelatedjobsDto) => {
        try {
            await deleteMutation.mutateAsync(row.id);
            notifications.show({
                title: 'موفقیت',
                message: 'شغل مرتبط با موفقیت حذف شد',
                color: 'green',
            });
            refetch();
        } catch (error) {
            notifications.show({
                title: 'خطا',
                message: 'خطا در حذف شغل مرتبط',
                color: 'red',
            });
        }
    };

    const handleAdd = () => {
        setEditingRelatedJob(null);
        open();
    };

    const handleSave = async (values: Partial<CurRelatedjobsDto>) => {
        try {
            if (editingRelatedJob) {
                await updateMutation.mutateAsync({ id: editingRelatedJob.id, ...values });
                notifications.show({
                    title: 'موفقیت',
                    message: 'شغل مرتبط با موفقیت ویرایش شد',
                    color: 'green',
                });
            } else {
                await createMutation.mutateAsync(values);
                notifications.show({
                    title: 'موفقیت',
                    message: 'شغل مرتبط جدید با موفقیت ایجاد شد',
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
                    <Title order={2}>مدیریت مشاغل مرتبط</Title>
                    <Text c="dimmed">مدیریت مشاغل مرتبط با آموزش</Text>
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
                    title={editingRelatedJob ? 'ویرایش شغل مرتبط' : 'افزودن شغل مرتبط جدید'}
                    size="md"
                >
                    <Stack gap="md">
                        <TextInput
                            label="نام شغل مرتبط"
                            placeholder="نام شغل مرتبط"
                            defaultValue={editingRelatedJob?.name || ''}
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
                                {editingRelatedJob ? 'ویرایش' : 'افزودن'}
                            </Button>
                        </Group>
                    </Stack>
                </Modal>
            </Stack>
        </BasePage>
    );
} 